using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("auctions")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionDao();
            }
            else
            {
                dao = auctionDao;
            }
        }

        [HttpGet("{id}")]
        public Auction GetAuctionByID(int id)
        {
            Auction auction = this.dao.Get(id);
            return auction;
        }

        [HttpPost]
        public Auction PostAuction(Auction auction)
        {
            auction = dao.Create(auction);
            return auction;
        }

        [HttpGet]
        public List<Auction> GetAuctions(string title_like = "", double currentBid_lte = 0)
        {
            if (string.IsNullOrEmpty(title_like) && currentBid_lte == 0)
            {
                return dao.List();
            }
            else if (currentBid_lte == 0)
            {
                return dao.SearchByTitle(title_like);
            }
            else if (string.IsNullOrEmpty(title_like))
            {
                return dao.SearchByPrice(currentBid_lte);
            }
            else return dao.SearchByTitleAndPrice(title_like, currentBid_lte);
        }
    }
}