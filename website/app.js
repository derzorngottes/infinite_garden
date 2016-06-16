const express = require('express');
const path = require('path');
const favicon = require('serve-favicon');
const logger = require('morgan');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const expressJwt = require('express-jwt');
const session = require('express-session');
const app = express();
app.io = require('socket.io')();

require('dotenv').load();
require('rootpath')();

app.set('view engine', 'pug');
app.set('views', __dirname + '/views');

app.use(favicon(path.join(__dirname, 'app', 'favicon.ico')));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));
app.use(session({
  secret: process.env.SECRET,
  cookie: { secure: 'auto', maxAge: 3600000 },
  saveUnitialized: true,
  resave: false }
));

// use JWT auth to secure the api
app.use('/api', expressJwt({ secret: process.env.SECRET }).unless({ path: ['/api/users/authenticate', '/api/users/register'] }));

// routes
app.use('/login', require('routes/login'));
app.use('/register', require('routes/register'));
app.use('/app', require('routes/app_access'));
app.use('/api/users', require('routes/api/users'));
app.use('/api/comments', require('routes/api/comments'));
app.use('/api/pictures', require('routes/api/pictures'));
app.use('/api/posts', require('routes/api/posts'));

// make '/app' default route
app.get('/', (req, res, next) => {
  return res.redirect('/app');
});

// catch 404 and forward to error handler
app.use((req, res, next) => {
  const err = new Error('Not Found');
  err.status = 404;
  next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
  app.use((err, req, res, next) => {
    res.status(err.status || 500);
    res.render('error', {
      message: err.message,
      error: err
    });
  });
}

// production error handler
// no stacktraces leaked to user
app.use((err, req, res, next) => {
  res.status(err.status || 500);
  res.render('error', {
    message: err.message,
    error: {}
  });
});

module.exports = app;
