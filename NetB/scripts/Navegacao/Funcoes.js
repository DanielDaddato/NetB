function ToastNotification(type, title, msg) {
    //Types:success/warning/error
    if (type === "success") { toastr.success(title, msg); }
    else if (type === "warning") { toastr.warning(title, msg); }
    else if (type === "error") { toastr.error(title, msg); }
}