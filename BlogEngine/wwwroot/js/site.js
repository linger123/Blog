// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function focusElement(id)
{
    let element = document.getElementById(id);
    element.focus();
    element.setSelectionRange(element.value.length, element.value.length);
}