﻿namespace formulate.api
{

    // Namespaces.
    using app.Helpers;
    using app.Managers;
    using app.Persistence;
    using app.Resolvers;
    using core.Models;
    using System;
    using ResolverConfig = app.Resolvers.Configuration;


    /// <summary>
    /// Handles operations related to rendering Formualte forms.
    /// </summary>
    public static class Rendering
    {

        #region Properties

        /// <summary>
        /// Configuration manager.
        /// </summary>
        private static IConfigurationManager Config
        {
            get
            {
                return ResolverConfig.Current.Manager;
            }
        }


        /// <summary>
        /// Form persistence.
        /// </summary>
        private static IFormPersistence Forms
        {
            get
            {
                return FormPersistence.Current.Manager;
            }
        }


        /// <summary>
        /// Layout persistence.
        /// </summary>
        private static ILayoutPersistence Layouts
        {
            get
            {
                return LayoutPersistence.Current.Manager;
            }
        }


        /// <summary>
        /// Validation persistence.
        /// </summary>
        private static IValidationPersistence Validations
        {
            get
            {
                return ValidationPersistence.Current.Manager;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Creates a view model for the specified form, layout, and template.
        /// </summary>
        /// <param name="formId">
        /// The form ID.
        /// </param>
        /// <param name="layoutId">
        /// The layout ID.
        /// </param>
        /// <param name="templateId">
        /// The template ID.
        /// </param>
        /// <returns>
        /// The view model.
        /// </returns>
        /// <remarks>
        /// This model is used to render a form.
        /// </remarks>
        public static FormViewModel GetFormViewModel(Guid? formId, Guid? layoutId, Guid? templateId)
        {
            var model = new FormViewModel();
            model.FormDefinition = DefinitionHelper.GetFormDefinition(formId);
            model.LayoutDefinition = DefinitionHelper.GetLayoutDefinition(layoutId);
            model.TemplatePath = DefinitionHelper.GetTemplatePath(templateId);
            return model;
        }

        #endregion

    }

}