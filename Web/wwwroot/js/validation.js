$(function () {
    jQuery.validator.addMethod('validateCPF',
        function (value, element, params) {

            var sum = 0;
            var remainder;
            var CPF = String(value.replace(/\D/g, ''));


            if (CPF.length !== 11)
                return false;

            var temp = '00000000000';
            for (i = 0; i < 9; i++) {
                if (CPF === temp)
                    return false;
                temp = String(parseInt(temp) + 11111111111);
            }

            for (i = 1; i <= 9; i++) {
                var digit = parseInt(CPF.substring(i - 1, i));
                sum += digit * (11 - i);
            }

            remainder = (sum * 10) % 11;

            if (remainder === 10 || remainder === 11)
                remainder = 0;

            if (remainder !== parseInt(CPF.substring(9, 10)))
                return false;

            sum = 0;

            for (i = 1; i <= 10; i++) {
                var digit = parseInt(CPF.substring(i - 1, i));
                sum += digit * (12 - i);
            }

            remainder = (sum * 10) % 11;

            if (remainder === 10 || remainder === 11)
                remainder = 0;

            if (remainder !== parseInt(CPF.substring(10, 11)))
                return false;
            else
                return true;
        });

    jQuery.validator.unobtrusive.adapters.add('validateCPF',
        [],
        function (options) {
            var element = $(options.form).find('input#Inscricao_Cpf');
            options.rules['validateCPF'] = true;
            options.messages['validateCPF'] = options.message;
        });
}(jQuery));