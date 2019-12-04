var options = {
    onKeyPress: function (telefone, e, field, options) {
        var masks = ['(00) 0000-0000', '(00) 00000-0000'];
        var mask = (parseInt(telefone.replace(/\D/g, '')[2]) === 9) ? masks[1] : masks[0];
        $('#Inscricao_Telefone01').mask(mask, options);
        $('#Inscricao_Telefone02').mask(mask, options);
    }
};

$('#Inscricao_Telefone01').mask('(00) 0000-0000', options);
$('#Inscricao_Telefone02').mask('(00) 0000-0000', options);



