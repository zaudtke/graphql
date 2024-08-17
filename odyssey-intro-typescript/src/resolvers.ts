import { Resolvers } from "./types";
import { validateFullAmenities } from "./helpers";

export const resolvers : Resolvers = {
    Query: {
        featuredListings : (_, __, { dataSources }) => {
            return dataSources.listingAPI.getFeaturedListings();
        },
        listing: (_, { id }, { dataSources }) => {
            return dataSources.listingAPI.getListing(id);
        },
    },
    Listing: {
        amenities: ({ id, amenities }, _, { dataSources }) => {
            // If `amenities` contains full-fledged Amenity objects, return them
            // Otherwise make a follow-up request to /listings/{listing_id}/amenities
            return validateFullAmenities(amenities)
                ? amenities
                : dataSources.listingAPI.getAmenities(id);
        }
    },
};