using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using SPAuth.DAL;
using MongoDB.AspNet.Identity;


namespace SPAuth.Models {
	public class AppContext : IdentityDbContext<User> {
		public AppContext()
			: base("DefaultConnection") {
		}
        public new static MongoDatabase Database { get; set; }
		//Db Sets
		//public virtual DbSet<Partner> Partners { get; set; }

		static AppContext() {
            var client = new MongoClient(MongoDbConfiguration.MongoDbClient);
            var server = client.GetServer();
            Database= server.GetDatabase(MongoDbConfiguration.DatabaseName);
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
			//Database.SetInitializer<AppContext>(new ApplicationDbInitializer());
        }

		public static AppContext Create() {
			return new AppContext();
        }
	}
}