using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IMailMessageRepository
 {
 Task<IEnumerable<MailMessage>> ListAsync();
 Task<IEnumerable<MailMessage>> ListByCoordinatorIdAsync(int coordinatorId);
 Task AddAsync(MailMessage mailMessage);
 Task<MailMessage> FindById(int id);
 void Update(MailMessage mailMessage);
 void Remove(MailMessage mailMessage);
 }
 }
