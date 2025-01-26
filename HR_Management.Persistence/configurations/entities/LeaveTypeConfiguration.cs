using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Persistence.configurations.entities;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType() { Id = 1, DefaultDay = 10, Name = "Sick" }
            , new LeaveType() { Id = 2, DefaultDay = 25, Name = "Vacation" });
    }
}