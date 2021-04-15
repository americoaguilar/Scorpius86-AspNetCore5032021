﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.MVC.Infrastructure.Data.Blog.Entities
{
    public partial class User
    {
        public User()
        {
            ComentarioUsuarioIdActualizacionNavigations = new HashSet<Comentario>();
            ComentarioUsuarioIdCreacionNavigations = new HashSet<Comentario>();
            ComentarioUsuarioIdPropietarioNavigations = new HashSet<Comentario>();
            PostUsuarioIdActualizacionNavigations = new HashSet<Post>();
            PostUsuarioIdCreacionNavigations = new HashSet<Post>();
            PostUsuarioIdPropietarioNavigations = new HashSet<Post>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Comentario> ComentarioUsuarioIdActualizacionNavigations { get; set; }
        public virtual ICollection<Comentario> ComentarioUsuarioIdCreacionNavigations { get; set; }
        public virtual ICollection<Comentario> ComentarioUsuarioIdPropietarioNavigations { get; set; }
        public virtual ICollection<Post> PostUsuarioIdActualizacionNavigations { get; set; }
        public virtual ICollection<Post> PostUsuarioIdCreacionNavigations { get; set; }
        public virtual ICollection<Post> PostUsuarioIdPropietarioNavigations { get; set; }
    }
}