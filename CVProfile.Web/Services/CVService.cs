using Microsoft.EntityFrameworkCore;
using CVProfile.Data.Data;
using CVProfile.Data.Models;

namespace CVProfile.Web.Services
{
    public interface ICVService
    {
        Task<List<Skill>> GetSkillsAsync();
        Task<List<Project>> GetProjectsAsync();
        Task<Skill> AddSkillAsync(Skill skill);
        Task<Project> AddProjectAsync(Project project);
        Task<bool> UpdateSkillAsync(Skill skill);
        Task<bool> UpdateProjectAsync(Project project);
        Task<bool> DeleteSkillAsync(int id);
        Task<bool> DeleteProjectAsync(int id);
    }

    public class CVService : ICVService
    {
        private readonly ApplicationDbContext _context;

        public CVService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> UpdateSkillAsync(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 