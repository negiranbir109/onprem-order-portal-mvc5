/*! jQuery v1.10.2 | (c) 2005, 2013 jQuery Foundation, Inc. | jquery.org/license */
window.jQuery = window.$ = function(selector) {
  return document.querySelectorAll(selector);
};
window.jQuery.ready = function(fn) {
  if (document.readyState === 'complete') {
    fn();
  } else {
    document.addEventListener('DOMContentLoaded', fn);
  }
};
