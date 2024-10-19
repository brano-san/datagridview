using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace datagridview.src
{
    static internal class Extensions
    {
        /// <summary>
        /// Создания Bindings для Control
        /// </summary>
        public static void AddBinding<TControl, TSource>(this TControl target,
            Expression<Func<TControl, object>> targetProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var targetName = GetMemberName(targetProperty);
            var sourceName = GetMemberName(sourceProperty);
            target.DataBindings.Add(new Binding(targetName, source, sourceName,
                false,
                DataSourceUpdateMode.OnPropertyChanged));

            if (errorProvider == null)
            {
                return;
            }

            var sourcePropertyInfo = source.GetType().GetProperty(sourceName);
            if (sourcePropertyInfo == null)
            {
                return;
            }

            var validators = sourcePropertyInfo.GetCustomAttributes<ValidationAttribute>();
            if (validators?.Any() == false)
            {
                return;
            }

            target.Validating += (sender, args) =>
            {
                var context = new ValidationContext(source);
                var results = new List<ValidationResult>();
                errorProvider.SetError(target, string.Empty);
                if (Validator.TryValidateObject(source, context, results, validateAllProperties: true))
                {
                    return;
                }

                foreach (var error in results.Where(x => x.MemberNames.Contains(sourceName)))
                {
                    errorProvider.SetError(target, error.ErrorMessage);
                }
            };
        }

        private static string GetMemberName<TItem, TMember>(Expression<Func<TItem, TMember>> targetMember)
        {
            if (targetMember.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (targetMember.Body is UnaryExpression unaryExpression)
            {
                var operand = unaryExpression.Operand as MemberExpression;

                if (operand == null)
                {
                    throw new NullReferenceException("GetMemberName: operand is null");
                }

                return operand.Member.Name;
            }

            throw new ArgumentException();
        }
    }
}
