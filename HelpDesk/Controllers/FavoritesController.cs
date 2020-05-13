using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HelpDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        IConfiguration ConfigRoot;
        DAL dal;

        public FavoritesController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("default"));
        }

        //Get all favorites
        [HttpGet("{id}")] 
        public IEnumerable<JoinedItem> GetAllFavorites(int id)
        {
            IEnumerable<JoinedItem> result = dal.AllFavorites(id);

            return result;
        }

        //Add to favorites
        // POST: api/Favorites
        [HttpPost]
        public int AddToFavorites(Favorite f)
        {
            int result = dal.AddToFavorites(f);
            return result;
        }
        //[HttpPost]
        //public Object AddToFavorites(Favorite f)
        //{
        //    return dal.AllFavorites(f.UserID);

        //    //int result = 0;

        //    //foreach (JoinedItem fav in faves)
        //    //{
        //    //    if (fav.TicketID == f.TicketID)
        //    //    {
        //    //        result
        //    //    }
        //    //}
    //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteFavoriteById(int id)
        {
            int result = dal.DeleteFavoriteByID(id);
            return result;
        }
    }
}
