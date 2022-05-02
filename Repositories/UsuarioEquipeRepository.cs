﻿using labware_webapi.Contexts;
using labware_webapi.Domains;
using labware_webapi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace labware_webapi.Repositories
{
    public class UsuarioEquipeRepository : IUsuarioEquipeRepository
    {
        LabWatchContext ctx = new LabWatchContext();

        public UsuarioEquipe Buscar(int id)
        {
            return ctx.UsuarioEquipes.FirstOrDefault(t => t.IdusuarioEquipe == id);
        }

        public void Cadastrar(UsuarioEquipe novaEquipe)
        {
            ctx.UsuarioEquipes.Add(novaEquipe);
            ctx.SaveChanges();
        }


        public void Deletar(int idEquipe)
        {
            ctx.UsuarioEquipes.Remove(Buscar(idEquipe));
            ctx.SaveChanges();
        }

        public List<UsuarioEquipe> ListarTodos()
        {
            return ctx.UsuarioEquipes.ToList();
        }

        public void MudarEquipe(int idUsuario, UsuarioEquipe EquipeAtualizada)
        {
            UsuarioEquipe equipeBuscada = Buscar(EquipeAtualizada.IdusuarioEquipe);

            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(p => p.IdUsuario == idUsuario);

            if (usuarioBuscado != null)
            {
                equipeBuscada.IdUsuario = usuarioBuscado.IdUsuario;

                ctx.Update(usuarioBuscado);

                ctx.SaveChanges();
            }

        }
    }
}
