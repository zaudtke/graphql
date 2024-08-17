import { ApolloServer } from "@apollo/server";
import { startStandaloneServer } from "@apollo/server/standalone";

import { readFileSync } from "fs";
import path from "path";
import { gql } from "graphql-tag";

import { resolvers } from "./resolvers";
import { ListingAPI } from "./datasources/listing-api";

const typeDefs = gql(
    readFileSync(path.resolve(__dirname, "./schema.graphql"), {
      encoding: "utf-8",
    })
  );

  async function startApolloServer() {
    const server = new ApolloServer({ 
        typeDefs,
        resolvers,
    });
    const { url } = await startStandaloneServer(server, {
        context: async() =>{
            const { cache } = server;
            // this object becomes our resolver's contextValue, the third positional argument
            return {
                dataSources: {
                    listingAPI: new ListingAPI({ cache }),
                },
            };
        },
    });
    console.log(`
        🚀  Server is running!
        📭  Query at ${url}
      `);
  }

  startApolloServer();