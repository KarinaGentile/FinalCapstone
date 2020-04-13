﻿using SmalltownCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.DAL
{
    public interface IPurchaseDAO
    {
        List<Ticket> GetReservedSeatsByShowingId(int showingId);

    }
}