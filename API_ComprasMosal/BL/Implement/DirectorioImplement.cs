﻿using API_ComprasMosal.DAL;
using API_Delivery.BL.DAO;
using API_Delivery.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Delivery.BL.Implement
{
    public class DirectorioImplement : DirectorioDAO
    {
        private readonly ApplicationDBContext context;

        public DirectorioImplement(ApplicationDBContext context)
        {
            this.context = context;
        }

        public int Create(Directorio entity)
        {
            context.Directorio.Add(entity);
            context.SaveChanges();
            return entity.idDirectorio;
        }

        public void Delete(Directorio entity)
        {
            Directorio DBEntity = context.Directorio.FirstOrDefault(e => e.idDirectorio == entity.idDirectorio);
            DBEntity.Estado = 0;
            context.SaveChanges();
        }

        public IEnumerable<Directorio> GetAll()
        {
            //return context.Directorio.ToList();
            throw new NotImplementedException();
        }

        public List<Directorio> GetAllActive()
        {
            return context.Directorio.Where(e => e.Estado == 1).ToList();
        }

        public Directorio GetById(long Id)
        {
            return context.Directorio.FirstOrDefault(e => e.idDirectorio == Id);
        }

        public void Update(Directorio DBEntity, Directorio entity)
        {
            DBEntity.Nombre = entity.Nombre;
            DBEntity.Apellido = entity.Apellido;
            DBEntity.Telefono = entity.Telefono;
            DBEntity.FechaNacimiento = entity.FechaNacimiento;
            DBEntity.Direccion = entity.Direccion;
            DBEntity.DUI = entity.DUI;
            DBEntity.Email = entity.Email;
            DBEntity.Estado = entity.Estado;
            context.SaveChanges();
        }
    }
}