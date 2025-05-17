﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiniAccountManagementSystem

{
    public class ApplicationIdentityDbContext: IdentityDbContext
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options): base(options)
        {
            
        }

    }
        
}
