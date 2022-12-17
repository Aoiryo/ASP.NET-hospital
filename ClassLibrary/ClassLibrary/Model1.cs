namespace ClassLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<bed> bed { get; set; }
        public virtual DbSet<department> department { get; set; }
        public virtual DbSet<departmentMedicalPersonnel> departmentMedicalPersonnel { get; set; }
        public virtual DbSet<examinationEquipment> examinationEquipment { get; set; }
        public virtual DbSet<hospitalizationRecord> hospitalizationRecord { get; set; }
        public virtual DbSet<injectingEquipment> injectingEquipment { get; set; }
        public virtual DbSet<medicalHistory> medicalHistory { get; set; }
        public virtual DbSet<medicalPersonnel> medicalPersonnel { get; set; }
        public virtual DbSet<medicalPersonnelExaminationEquipment> medicalPersonnelExaminationEquipment { get; set; }
        public virtual DbSet<medicalPersonnelInjectingEquipment> medicalPersonnelInjectingEquipment { get; set; }
        public virtual DbSet<medicalPersonnelMedicine> medicalPersonnelMedicine { get; set; }
        public virtual DbSet<medicine> medicine { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<patient> patient { get; set; }
        public virtual DbSet<permission> permission { get; set; }
        public virtual DbSet<registrationSession> registrationSession { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<rolePermission> rolePermission { get; set; }
        public virtual DbSet<room> room { get; set; }
        public virtual DbSet<scheduling> scheduling { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<visitRecord> visitRecord { get; set; }
    }
}