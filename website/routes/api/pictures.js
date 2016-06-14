const express = require('express');
const router = express.Router();
const server = require('../bin/www');
const io = require('socket.io')(server);
const socket =  io();
const Picture = require('../../services/pictures');

// routes
router.get('/pic/:id', getById);
router.get('/user/:id', getAllbyUser);
router.post('/add', addPicture);
router.put('/update', updatePicture);
router.delete('/delete', deletePicture);

module.exports = router;

function getById(req, res, next) {
  Picture.getById(req.params.id, (error, pic) => {
    if (error) {
      res.status(400).send(error);
    }
    else if (pic) {
      res.send(pic);
    }
    else {
      res.sendStatus(404);
    }
  });
}

function getAllbyUser(req, res, next) {
  Picture.getAllbyUser(req.params.id, (error, pics) => {
    if (error) {
      res.status(400).send(error);
    }
    else if (pics) {
      res.send(pics);
    }
    else {
      res.sendStatus(404);
    }
  });
}

function addPicture(req, res, next) {
  Picture.addPic(req.body, (error, newPic) => {
    if (error) {
      res.status(400).send(error);
    }
    else if (newPic) {

    }
    else
  });
}
