const express = require("express");
const app = express();
require('dotenv').config();
const port = process.env.PORT;
    
require("./config/mongoos.config");
    
app.use(express.json(), express.urlencoded({ extended: true }));
    
const JokesRoutes = require("./routes/joke.routes");
JokesRoutes(app);
    
app.listen(port, () => console.log(`Listening on port: ${port}`) );
