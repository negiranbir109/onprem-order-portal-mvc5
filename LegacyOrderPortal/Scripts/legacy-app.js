document.addEventListener('DOMContentLoaded', function () {
  var alerts = document.querySelectorAll('.alert-dismissible .close');
  alerts.forEach(function (close) {
    close.addEventListener('click', function () {
      this.parentNode.style.display = 'none';
    });
  });
});
