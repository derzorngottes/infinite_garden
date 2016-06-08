const jwt = require('jsonwebtoken');
const knex = require('../db/knex');
const bcrypt = require('bcrypt');
const SALT_WORK_FACTOR = 10;

function user() {
  return knex('users');
}

user.authenticate = (username, password, callback) => {
  user().where({ username: username }).first().then(user => {
    if (!user) {
      return callback("username does not exist");
    }
    bcrypt.compare(password, user.password_digest, (err, isMatch) => {
      if (err || !isMatch) {
        return callback("username and password don't match");
      } else {
        return callback(undefined, jwt.sign({ sub: user.id }, process.env.SECRET));
      }
    });
  });
}

user.createUser = (data, callback) => {
  bcrypt.genSalt(SALT_WORK_FACTOR, (err, salt) => {
    if (err) {
      callback(err);
    }

    bcrypt.hash(data.password, salt, (err, hash) => {
      if (err) {
        callback(err);
      }

      data.password_digest = hash;
      delete data.password;

      user().insert(data, '*').then(user => {
        callback(undefined, user);
      })
      .catch(error => {
        callback(error);
      });
    });
  });
}

user.getAll = callback => {
  user().select().then(users => {
    callback(undefined, users);
  })
  .catch(error => {
    callback(error);
  });
}

user.getById = (id, callback) => {
  user().where({ id: id }).then(user => {
    callback(undefined, user);
  })
  .catch(error => {
    callback(error);
  });
}

user.getByUsername = (username, callback) => {
  user().where({ username: username }).then(user => {
    callback(undefined, user);
  })
  .catch(error => {
    callback(error);
  });
}

user.updateUser = (id, userParam, callback) => {
  if (userParam.password) {
    bcrypt.hash(userParam.password, salt, (error, hash) => {
      if (error) {
        callback(error);
      }

      userParam.password_digest = hash;
      delete userParam.password;

      user()
        .where({ id: id })
        .update({ username: userParam.username, password_digest: userParam.password_digest, avatar: userParam.avatar }, '*')
        .then(user => {
          callback(undefined, user);
        })
        .catch(error => {
          callback(error);
        });
    });
  }
  else {
    user()
      .where({ id: id })
      .update({ username: userParam.username, avatar: userParam.avatar }, '*')
      .then(user => {
        callback(undefined, user);
      })
      .catch(error => {
        callback(error);
      });
  }
}

user.deleteUser = (id, callback) => {
  user().where({ id: id }).del().then(row => {
    callback(undefined, row);
  })
  .catch(error => {
    callback(error);
  });
}

module.exports = user;
