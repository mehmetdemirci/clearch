const dev = {
    API_URL: "https://localhost:5001"
};

const prod = {
    API_URL: "https://API.YourDomainHere.io"
};

const config = process.env.NODE_ENV === 'development' ? dev : prod;
export default config;