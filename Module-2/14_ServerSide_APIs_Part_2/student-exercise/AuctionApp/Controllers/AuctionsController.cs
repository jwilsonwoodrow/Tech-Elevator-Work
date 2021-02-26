﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            dao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }

            return dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = dao.Get(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            if (dao.Create(auction) != null)
            {
                return Created("controller", dao.Create(auction));
            }
            else return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<Auction> Update(Auction auction, int id)
        {
            Auction returnAuction = dao.Update(id, auction);
            if (returnAuction != null)
            {
                return returnAuction;
            }
            else return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (dao.Delete(id))
            {
                return NoContent();
            }
            else return NotFound();
        }

    }
}
