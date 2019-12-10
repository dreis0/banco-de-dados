using Dapper;
using Domain;
using System.Data;

namespace Application.Pedidos
{
    public partial class PedidoEntregue
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;

            public CommandHandler(IDbConnection db)
            {
                connection = db;
            }

            public void Handle(int pedidoId)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    string sqlEntregue = $"update {new Pedido().GetTableName()} set " +
                                        @"StatusId = @status 
                                            where Id = @pedidoId";

                    connection.Execute(sqlEntregue, param: new { status = (int)eStatusPedido.Entregue, pedidoId }, transaction: transaction);
                    transaction.Commit();
                }

                connection.Close();
            }
        }
    }
}
