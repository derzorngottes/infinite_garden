var relay = {
  SendImgurData: function(data) 
  {
  	relayImgurData(Pointer_stringify(data));
  }
};
mergeInto(LibraryManager.library, MyPlugin);
