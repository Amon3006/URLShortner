import api from "./axios";

export const createShortUrl = (originalUrl) => {
    return api.post("/url", {
        originalUrl
    });
};

export const getAllUrls = () => {
    return api.get("/url");
};