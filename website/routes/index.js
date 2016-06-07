const express = require('express');
const router = express.Router();
const User = require('../knex_lib/users');

/* GET home page. */
router.get('/', (req, res, next) => {
  res.render('index');
});

module.exports = router;
