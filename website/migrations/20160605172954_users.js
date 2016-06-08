
exports.up = function(knex, Promise) {
  return knex.schema.createTable('users', function(table){
    table.increments();
    table.string('username', 15).unique().notNullable();
    table.string('password_digest');
    table.string('avatar');
  });
};

exports.down = function(knex, Promise) {
  return knex.schema.dropTable('users');
};
