
namespace RockPaper.Web
{

    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Response;
    using System;

    /// <summary>
    /// The generic resource API interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiController<T>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [HttpPost]
        ResponseItem<T> Post(T resource);

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        //[HttpGet]
        //ResponseList<T> Get();


        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns></returns>
        ResponseItem<bool> Delete();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The resource</returns>
        [HttpGet]
        ResponseItem<T> Get(Guid id);


        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The item list</returns>
        [HttpPut]
        ResponseList<T> Put(IEnumerable<T> items);

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Delete success</returns>
        [HttpDelete]

        [HttpPut]
        ResponseItem<T> Put(Guid id, T item);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete success</returns>
        [HttpDelete]
        ResponseItem<bool> Delete(Guid id);
    }
}