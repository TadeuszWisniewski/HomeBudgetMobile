﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.Services
{
    public interface IDataStore<T>
    {
        /// <summary>
        /// It is responsible for refreshing internal cache
        /// </summary>
        /// <returns></returns>
        Task Refresh();
        /// <summary>
        /// Managing adding item to the service and handling cache.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> AddItemAsync(T item);
        /// <summary>
        /// Managing updating item to the service and handling cache.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(T item);
        /// <summary>
        /// Managing deleting item to the service and handling cache.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(int id);
        /// <summary>
        /// Managing getting item from cache.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<T> GetItemAsync(int id);
        /// <summary>
        /// Invoking refresh with force refresh flag
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
