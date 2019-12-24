using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStudy.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WebApiStudy.Data.Repository.EntityRepository.BidRepo;
using WebApiStudy.EntityModel.BidModels;

namespace WebApiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository bidRepo;
        private readonly IMapper mapper;

        public BidController(IBidRepository bidRepo, IMapper mapper)
        {
            this.bidRepo = bidRepo;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<BidModel> GetBid(int id)
        {
            BidModel bid = mapper.Map<Bid, BidModel>(bidRepo.Get(id)); ;
            if (bid == null)
                return NotFound();
            else
                return mapper.Map<Bid, BidModel>(bidRepo.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BidModel>> GetBidsList()
        {
            return mapper.Map<List<Bid>, List<BidModel>>(bidRepo.GetAll().ToList());
        }

        [HttpPost]
        public ActionResult<Bid> PostBid(BidModel bid)
        {
            try
            {
                Bid b = mapper.Map<BidModel, Bid>(bid);
                bidRepo.Add(b);
                bidRepo.SaveChanges();
            } catch (SqlException)
            {
                return BadRequest();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (Exception){
                return StatusCode(500);
            }
            return CreatedAtAction("getBid", new { id = bid.ID }, bid);
        }

        [HttpPut("{id}")]
        public ActionResult<BidModel> PutBid(int id, BidPutModel model)
        {
            Bid bid = mapper.Map<BidPutModel, Bid>(model);
            bid.ID = id;
            try
            {
                bidRepo.Update(bid);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bidRepo.BidExists(bid))
                    return NotFound();
                //else
                //    throw;
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Bid> DeleteBid(int id)
        {
            Bid bid = bidRepo.Get(id);
            if (bid == null)
                return NotFound();
            bidRepo.Remove(bid);
            bidRepo.SaveChanges();
            return bid;
        }
    }
}