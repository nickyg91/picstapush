using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Picstapush.Dto.Interfaces;

namespace Picstapush.Data.PicstapushDb.Entities
{
    [Table("user")]
    public class User : IPicstapushUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }
        [StringLength(128), Column("email")]
        public string Email { get; set; }
        [StringLength(64), Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
    }
}