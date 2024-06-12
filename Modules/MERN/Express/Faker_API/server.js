const { faker } = require('@faker-js/faker');
const express = require("express");

const app = express();
const port = 8000;

app.get('api/users', (req, res) => {

})

// we can create a function to return a random / fake "Product"
const createUser = () => {
    const newUser = {
        'password': faker.internet.password(),
        'email': faker.internet.email(),
        'phoneNumber': faker.phone.number(),
        'firstName': faker.person.firstName(),
        'lastName': faker.person.lastName(),
        '_id': faker.string.uuid()
    };
    return newUser;
};


const createCompnay = () => {
    const newCompany = {
        '_id': faker.string.uuid(),
        'name': faker.company.name(),
        'adress': {
            'street' : faker.location.streetAddress(),
            'city' : faker.location.city(),
            'state' : faker.location.state(),
            'zipCode' : faker.location.zipCode(),
            'country' : faker.location.country()
        }
    };
    return newCompany;
};

app.get('/api/users/new', (req, res) => {
    const user = createUser();
    res.json( user );
})

app.get('/api/companies/new', (req, res) => {
    const user = createUser();
    res.json( user );
})   

app.get('/api/user/company', (req, res) => {
    const user = createUser();
    const company = createCompnay();
    res.json( {
        'newUser': user,
        'newCompany': company
    } );
})   

app.listen(port, () => console.log('Server is running...'))
