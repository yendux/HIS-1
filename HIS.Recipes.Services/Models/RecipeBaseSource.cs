﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HIS.Data.Base.Interfaces.Models;
using HIS.Recipes.Models.Enums;

namespace HIS.Recipes.Services.Models
{
    internal abstract class RecipeBaseSource : INamedEntity<Guid>
    {

        #region CONST
        #endregion

        #region FIELDS
        #endregion

        #region CTOR

        public RecipeBaseSource()
        {
            RecipeSourceRecipes = new HashSet<RecipeSourceRecipe>();
        }
        #endregion

        #region METHODS

        public SourceType GetSourceType()
        {
            SourceType result;

            if (this is RecipeCookbookSource)
            {
                result = SourceType.Cookbook;
            }
            else if (this is RecipeUrlSource)
            {
                result = SourceType.WebSource;
            }
            else
            {
                throw new ArgumentException($"Source Type must inherit from Type '{nameof(RecipeBaseSource)}'");
            }

            return result;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// DB Key
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<RecipeSourceRecipe> RecipeSourceRecipes { get; set; }
        #endregion
    }
}
