import _axios from "axios";
import { requestInterceptor, responseInterceptor } from "./interceptors";

const axios = _axios.create({
    // Append endpoint url as the base API url for production.
    // In the development environment, this will be automatically handled by setupProxy.js
    baseURL: 'https://localhost:7100',
})

// axios.interceptors.request.use(requestInterceptor)
// axios.interceptors.response.use(responseInterceptor)

export default axios