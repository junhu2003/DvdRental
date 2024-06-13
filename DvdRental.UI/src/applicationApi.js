const baseUrl = 'https://localhost:7194';

export const ApplicationApi = {

    getCustomers: async (firstName, lastName, email) => {        
        var reqUrl = baseUrl + '/api/DvdRental/RetrieveCustomers?firstName=' + firstName + '&lastName=' + lastName + '&email=' + email;
        const response = await fetch(reqUrl, { method: 'GET', credentials: 'include', mode: 'cors'});
        return response.json();
    },

    gerRentalsByCustomer: async (custId) => {
        var reqUrl = baseUrl + '/api/DvdRental/RetrieveRentalsByCustomer?custId=' + custId;
        const response = await fetch(reqUrl, { method: 'GET', credentials: 'include', mode: 'cors'});
        return response.json();
    },
    
    getFilmByRental: async (rentalId) => {
        var reqUrl = baseUrl + '/api/DvdRental/RetrieveFilmByRental?rentalId=' + rentalId;
        const response = await fetch(reqUrl, { method: 'GET', credentials: 'include', mode: 'cors'});
        return response.json();
    }

};