const express = require('express');
const router = express.Router();
const User = require('../public/javascripts/users-auth.js');

/* GET home page. */
router.get('/', (req, res, next) => {
  res.render('index');
});

module.exports = router;
