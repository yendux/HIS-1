﻿using System;
using System.Threading.Tasks;
using HIS.Recipes.Models.ViewModels;
using Microsoft.Extensions.FileProviders;

namespace HIS.Recipes.WebApi.Client.Services.Interfaces
{
    public interface IRecipeImageService:IDisposable
    {
        /// <summary>
        /// Gets all Images of a Recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        Task<ListViewModel<RecipeImageViewModel>> GetRecipeImages(int recipeId);

        /// <summary>
        /// Create a new Recipe image
        /// </summary>
        /// <param name="recipeId">Id of a Recipe</param>
        /// <param name="newFile">Image file</param>
        /// <returns></returns>
        Task<RecipeImageViewModel> AddRecipeImageAsync(int recipeId, IFileInfo newFile);

        /// <summary>
        /// Removes an existing image
        /// </summary>
        /// <param name="recipeId">Id of a Recipe</param>
        /// <param name="imageId">Id of an Image</param>
        /// <returns></returns>
        Task DeleteRecipeImageAsync(int recipeId, int imageId);
    }
}
