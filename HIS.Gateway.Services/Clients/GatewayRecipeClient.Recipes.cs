﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIS.Helpers.Extensions;
using HIS.Recipes.Models.ViewModels;
using Microsoft.AspNetCore.WebUtilities;

namespace HIS.Gateway.Services.Clients
{
    internal partial class GatewayRecipeClient
    {
        #region CONST
        #endregion

        #region FIELDS
        #endregion

        #region CTOR
        #endregion

        #region METHODS
        /// <summary>
        /// Gets Recipes from the Recipe-API
        /// </summary>
        /// <param name="searchModel">searchterm to filter</param>
        /// <param name="page">page for pagination</param>
        /// <param name="entriesPerPage">entries per page for pagination</param>
        /// <returns></returns>
        public async Task<ListViewModel<ShortRecipeViewModel>> GetRecipes(RecipeSearchViewModel searchModel = null, int page = 0, int entriesPerPage = 10)
        {
            var newUrl = new Uri(this.Client.BaseAddress, "Recipes/");
            var query = "";

            if (searchModel != null)
            {
                var searchQuery = this.Client.ConvertToQueryString(searchModel);
                if (!String.IsNullOrWhiteSpace(searchQuery))
                {
                    query = $"?{searchQuery}";
                }
            }

            query = QueryHelpers.AddQueryString(query, nameof(page), page.ToString());
            query = QueryHelpers.AddQueryString(query, nameof(entriesPerPage), entriesPerPage.ToString());

            return await this.Client.GetAsync<ListViewModel<ShortRecipeViewModel>>(new Uri(newUrl, query).ToString());
        }

        /// <summary>
        /// Get full Recipe information
        /// </summary>
        /// <param name="recipeId">Id of a recipe</param>
        /// <returns></returns>
        public async Task<FullRecipeViewModel> GetRecipeAsync(int recipeId)
        {
            return await this.Client.GetAsync<FullRecipeViewModel>($"Recipes/{recipeId}");
        }

        /// <summary>
        /// Removes a Recipe
        /// </summary>
        /// <param name="recipeId">Id of a recipe</param>
        /// <returns></returns>
        public async Task DeleteRecipeAsync(int recipeId)
        {
            await this.Client.DeleteAsync($"Recipes/{recipeId}");
        }

        /// <summary>
        /// Changes an existing Recipe
        /// </summary>
        /// <param name="recipeId">Id of a recipe</param>
        /// <param name="updatedModel">Model with new Data</param>
        /// <returns></returns>
        public async Task UpdateRecipeAsync(int recipeId, RecipeUpdateViewModel updatedModel)
        {
            await this.Client.PutAsJsonAsync(updatedModel, $"Recipes/{recipeId}");
        }

        /// <summary>
        /// Creates a new Recipe
        /// </summary>
        /// <param name="model">Recipe-Data</param>
        /// <returns></returns>
        public async Task<RecipeUpdateViewModel> CreateRecipeAsync(RecipeCreationViewModel model)
        {
            return await this.Client.PostAsJsonReturnAsync<RecipeCreationViewModel, RecipeUpdateViewModel>(model, "Recipes");
        }

        /// <summary>
        /// Starts a cooking of a recipe
        /// </summary>
        /// <param name="recipeId">id of a recipe</param>
        /// <returns></returns>
        public async Task StartCookingAsync(int recipeId)
        {
            await this.Client.PostAsync($"Recipes/{recipeId}/cooking");
        }
        #endregion

        #region PROPERTIES
        #endregion

    }
}
