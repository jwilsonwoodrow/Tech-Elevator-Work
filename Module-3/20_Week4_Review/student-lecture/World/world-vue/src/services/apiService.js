// Contains all functions which call the API
import axios from 'axios'

const http = axios.create({
    baseURL: 'https://localhost:44390/api'
})

export default {
    getCities(countryCode, district) {
        let url = '/cities';
        if(countryCode){
            url += "?countryCode=" + countryCode
            if(district){
                url += `&district=${district}`
            }
        }
    }
}