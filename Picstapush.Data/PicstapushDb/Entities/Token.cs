using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Picstapush.Dto.Interfaces;

namespace Picstapush.Data.PicstapushDb.Entities
{
    [Table("token")]
    public class Token : IToken
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("token_string")]
        public string TokenString { get; set; }
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        [Column("expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
