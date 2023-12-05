using UnityEngine;
using MongoDB.Driver;
using TMPro;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class MongoDBManager : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Jugador> jugadoresCollection;
    public TMP_Text textoUI;
    public TMP_Text score;


    private void Start()
    {
        string connectionString = "mongodb+srv://mariagmenr:laravel8@cluster0.u0z54ln.mongodb.net/?retryWrites=true&w=majority";
        client = new MongoClient(connectionString);
        database = client.GetDatabase("Educalumnos");
        jugadoresCollection = database.GetCollection<Jugador>("jugadores");
        ConsultarMejoresPuntajes();
        print(score);
    }


    public void RegistrarJugador(string nombre)
    {
        Jugador nuevoJugador = new Jugador { Nombre = nombre, Puntaje = 0 };
        jugadoresCollection.InsertOne(nuevoJugador);

        Debug.Log("Jugador registrado en MongoDB: " + nombre);
    }

    void ConsultarMejoresPuntajes()
    {
        var collection = database.GetCollection<BsonDocument>("jugadores");

        var filtro = Builders<BsonDocument>.Filter.Empty;

        var opcionesOrden = Builders<BsonDocument>.Sort.Descending("Puntaje");

        var resultados = collection.Find(filtro).Sort(opcionesOrden).Limit(5).ToList();

        // Procesa los resultados.
        foreach (var documento in resultados)
        {
            var nombre = documento["Nombre"].AsString;
            var puntaje = documento["Puntaje"].AsInt32;

            textoUI.text += $"{nombre}     {puntaje}\n";
        }
    }

    // public void SumarPuntos(string nombreJugador, int puntos)
    // {
    //     var filtro = Builders<Jugador>.Filter.Eq(j => j.Nombre, nombreJugador);
    //     var update = Builders<Jugador>.Update.Inc(j => j.Puntaje, puntos);

    //     jugadoresCollection.UpdateOne(filtro, update);

    //     Debug.Log($"Se sumaron {puntos} puntos al jugador {nombreJugador}.");
    // }
    public void SumarPuntos(string nombreJugador, int puntos)
    {
        var filtro = Builders<Jugador>.Filter.Eq(j => j.Nombre, nombreJugador);
        var update = Builders<Jugador>.Update.Inc(j => j.Puntaje, puntos);

        jugadoresCollection.UpdateOne(filtro, update);

        // Obtener el puntaje actualizado después de la actualización
        var jugadorActualizado = jugadoresCollection.Find(filtro).FirstOrDefault();
        int nuevoPuntaje = jugadorActualizado != null ? jugadorActualizado.Puntaje : 0;

        // Mostrar solo el puntaje en la interfaz de usuario
        MostrarPuntajeEnUI(nuevoPuntaje);

        Debug.Log($"Se sumaron {puntos} puntos al jugador {nombreJugador}. Puntaje actual: {nuevoPuntaje}");
    }

    private void MostrarPuntajeEnUI(int puntaje)
    {
        print(puntaje.ToString());
        score.text = puntaje.ToString();
    }



}

public class Jugador
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Nombre { get; set; }
    public int Puntaje { get; set; }
}
