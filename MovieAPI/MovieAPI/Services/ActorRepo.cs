using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Infrastructure;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class ActorRepo : BaseRepo<Actor>, IActorRepo
    {

        public ActorRepo(Context context) : base(context)
        {
            
        }

    }
}
