using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Senac.GCP.API.Models.Base
{
    public abstract class Model
    {
        public long? Id { get; set; }

        public virtual void AdditionalValidations() { }

        public TEntity ToEntity<TEntity>(long idValue)
        {
            var result = ToEntity<TEntity>();
            var properties = result.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<KeyAttribute>();
                if (attribute != null)
                {
                    if (property.PropertyType != typeof(long))
                    {
                        throw new Exception($"Property '{property.Name}' is not type 'Int64' in entity.");
                    }

                    property.SetValue(result, idValue);
                    return result;
                }
            }

            return result;
        }

        public TEntity ToEntity<TEntity>()
        {
            var entity = Activator.CreateInstance<TEntity>();
            var modelProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var entityProperties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var modelProperty in modelProperties)
            {
                if (modelProperty.PropertyType.IsValueType || modelProperty.PropertyType == typeof(string) || modelProperty.PropertyType == typeof(byte[]))
                {
                    var entityProperty = entityProperties.FirstOrDefault(item => item.Name == modelProperty.Name);
                    if (entityProperty != null)
                    {
                        if (modelProperty.PropertyType == entityProperty.PropertyType)
                        {
                            entityProperty.SetValue(entity, modelProperty.GetValue(this));
                        }
                        else if (entityProperty.PropertyType.IsEnum)
                        {
                            entityProperty.SetValue(entity, modelProperty.GetValue(this));
                        }
                    }
                }
            }

            return entity;
        }
    }

    public static class ModelExtension
    {
        public static void Validate(this Model model, bool validateId = false)
        {
            if (model is null)
            {
                throw new ArgumentNullException("O Model não foi serializado corretamente. \nVerifique quais propriedades foram definidas incorretamente.");
            }
            else if (validateId && model.Id is null)
            {
                throw new Exception("ID não definido para atualização de dados.");
            }

            var validations = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            if (!Validator.TryValidateObject(model, context, validations, true))
            {
                var messages = new StringBuilder();
                validations.ForEach(item => messages.AppendLine(item.ErrorMessage));
                throw new Exception(messages.ToString());
            }

            ApplyAttributeDateOnly(model);
            ApplyAttributeStringOptions(model);
            model.AdditionalValidations();
        }

        private static void ApplyAttributeDateOnly(Model model)
        {
            var properties = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                var custom = property.GetCustomAttribute<DateOnlyAttribute>();
                if (custom != null)
                {
                    var objectValue = property.GetValue(model);
                    if (objectValue != null && objectValue is DateTime)
                    {
                        var value = Convert.ToDateTime(objectValue).Date;
                        property.SetValue(model, value);
                    }
                }
            }
        }

        private static void ApplyAttributeStringOptions(Model model)
        {
            var properties = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var custom = property.GetCustomAttribute<StringOptionsAttribute>();
                if (custom != null)
                {
                    var objectValue = property.GetValue(model);
                    if (objectValue != null && objectValue is string)
                    {
                        string value = objectValue.ToString();
                        switch (custom.TrimSpace)
                        {
                            case TrimSpaceEnum.Both: property.SetValue(model, value.Trim()); value = value.Trim(); break;
                            case TrimSpaceEnum.End: property.SetValue(model, value.TrimEnd()); value = value.TrimEnd(); break;
                            case TrimSpaceEnum.Start: property.SetValue(model, value.TrimStart()); value = value.TrimStart(); break;
                        }

                        switch (custom.AlterCase)
                        {
                            case AlterCaseEnum.Lower: property.SetValue(model, value.ToLower()); break;
                            case AlterCaseEnum.Upper: property.SetValue(model, value.ToUpper()); break;
                        }
                    }
                }
            }
        }
    }
}