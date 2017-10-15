﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IPhotoRepository
    {
        IQueryable<Photo> Photos { get; }
        void SavePhoto(Photo phot);
        Photo DeletePhoto(int photoID);
    }
}
