using GraphQLDirector.Data;
using GraphQLDirector.GraphQL.Streamers;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddStreamerPayload> AddStreamerAsync(AddStreamerInput input,
            [ScopedService] ApiDbContext context)
        {
            var streamer = new Streamer();
            streamer.Nombre = input.nombre;
            streamer.Url = input.url;

            context.Streamers!.Add(streamer);

            await context.SaveChangesAsync();

            return new AddStreamerPayload(streamer);
        }


    }
}
