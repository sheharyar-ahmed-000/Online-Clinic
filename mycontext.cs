using Microsoft.EntityFrameworkCore;
namespace clinic.Models
{
	public class mycontext : DbContext
	{
        public mycontext(DbContextOptions<mycontext> options) : base(options)
        {
            
        }
        public DbSet<admin> tbl_admin {  get; set; }
        public DbSet<client> tbl_client {  get; set; }
        public DbSet<medicines> tbl_medicines {  get; set; }
        public DbSet<medicinecategory> tbl_medicinecateogry {  get; set; }
        public DbSet<scientifictools> tbl_scitools {  get; set; }
        public DbSet<educationevents> tbl_educationevents {  get; set; }
        public DbSet<feedback> tbl_feedback {  get; set; }
        public DbSet<bussinesstransaction> tbl_bussinesstransaction {  get; set; }
        public DbSet<clinicgallery> tbl_gallery {  get; set; }
        public DbSet<teachers> tbl_teacher {  get; set; }
        public DbSet<scitwo> tbl_scitwo {  get; set; }
        public DbSet<contact> tbl_contact {  get; set; }
        public DbSet<cart> tbl_cart {  get; set; }
       

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<medicines>().HasOne(c => c.medicinecat).WithMany(m => m.medicines).HasForeignKey(c => c.medicinecat_id);
		}
	}
}
