﻿using AgendApp.Models;
using AgendApp.Requests;
using Microsoft.EntityFrameworkCore;

namespace AgendApp.Services
{
    public interface IMedService
    {
        Task<Object> postCategorie(CategorieRequest request);
        Task<Object> getCategorie(int id);
        Task<Object> getCategories();

        Object editSchedule(int id, ScheduleEditRequest request);
        Object editCategorie(int id, CategorieEditRequest request);
        Task<Object> setSchedule(ScheduleRequest request);
        Task<Object> getSchedules();
        Task<Object> getSchedule(int id);
        Task<Object> getMedicos();
        Task<Object> getCitas(int idMed);
        Task<Object> getMedico(int id);

    }
    public class MedService : IMedService
    {
        private AgendappDbContext _db;
        public MedService(AgendappDbContext context)
        {
            this._db = context;
        }

        public async Task<Object> postCategorie(CategorieRequest request)
        {
            try
            {
                Categoriasmedica newCategorie = new Categoriasmedica
                {
                    Nombre = request.nombre
                };

                var addedCategorie = await _db.Categoriasmedicas.AddAsync(newCategorie);
                await _db.SaveChangesAsync();

                return new
                {
                    status = 200,
                    success = true,
                    data = addedCategorie.Entity
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }
        public async Task<Object> getCategorie(int id)
        {
            try
            {
                Categoriasmedica? categorie = await _db.Categoriasmedicas.FirstOrDefaultAsync(c => c.IdCategoria == id);

                if (categorie == null)
                {
                    return new
                    {
                        status = 400,
                        success = false,
                        message = "Categoria medica no existe"
                    };
                }

                return new
                {
                    status = 200,
                    success = true,
                    data = categorie
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> getCategories()
        {
            try
            {

                List<Categoriasmedica> categories = await _db.Categoriasmedicas.ToListAsync<Categoriasmedica>();

                return new
                {
                    status = 200,
                    success = true,
                    data = categories
                };

            }catch(Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> setSchedule(ScheduleRequest request)
        {
            try
            {
                Horario newSchedule = new Horario
                {
                    Rango = request.rango
                };

                var schedule = await _db.Horarios.AddAsync(newSchedule);

                await _db.SaveChangesAsync();

                return new
                {
                    status = 200,
                    success = true,
                    data = schedule.Entity
                };
                
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public Object editSchedule(int id, ScheduleEditRequest request) {
            try
            {
                Horario? horario = _db.Horarios.FirstOrDefault(h => h.IdHorario == id);

                if (horario == null)
                {
                    return new
                    {
                        status = 400,
                        success = false,
                        message = "horario no existe"
                    };
                }

                horario.Rango = request.rango;

                Horario? updatedSchedule = _db.Horarios.Update(horario).Entity;
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = horario
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public Object editCategorie(int id, CategorieEditRequest request)
        {
            try
            {
                Categoriasmedica? categorie = _db.Categoriasmedicas.FirstOrDefault(c => c.IdCategoria == id);

                if (categorie == null)
                {
                    return new
                    {
                        status = 400,
                        success = false,
                        message = "categoria no existe"
                    };
                }

                categorie.Nombre = request.nombre;

                Categoriasmedica? updatedCategorie = _db.Categoriasmedicas.Update(categorie).Entity;
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = updatedCategorie
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> getSchedules()
        {
            try
            {
                List<Horario> schedules = await _db.Horarios.ToListAsync<Horario>();

                return new
                {
                    status = 200,
                    success = true,
                    data = schedules
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> getMedico(int id)
        {
            try
            {
                Medico? medico = await _db.Medicos.Include(i => i.IdUsuarioNavigation)
                    .FirstOrDefaultAsync(m => m.IdMedico == id);
                
                if(medico == null)
                {
                    return new
                    {
                        status = 400,
                        success = false,
                        message = "Medico no existe"
                    };
                }

                return new
                {
                    status = 200,
                    success = true,
                    data = medico
                };

            }catch(Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> getMedicos()
        {
            try
            {


                List<Medico> medicos = await _db.Medicos.Include(i => i.IdUsuarioNavigation).ToListAsync();

                return new
                {
                    status = 200,
                    success = true,
                    data = medicos
                };

            }catch(Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> getCitas(int idMed)
        {
            try
            {
                List<Cita> citas = await _db.Citas.Where(c => c.IdMedico == idMed).ToListAsync();

                return new
                {
                    status = 200,
                    success = true,
                    data = citas
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }
        public async Task<Object> getSchedule(int id)
        {
            try
            {
                Horario? horario = await _db.Horarios.FirstOrDefaultAsync(h => h.IdHorario == id);

                if(horario == null)
                {
                    return new
                    {
                        status = 400,
                        success = false,
                        message = "Horario no existe"
                    };
                }

                return new
                {
                    status = 200,
                    success = true,
                    data = horario
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }
    }
}
