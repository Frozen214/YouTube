 private void SendMessage()
        {
            // Настройки SMTP-сервера Mail.ru
            string smtpServer = "smtp.mail.ru"; //smpt сервер(зависит от почты отправителя)
            int smtpPort = 587; // Обычно используется порт 587 для TLS
            string smtpUsername = "artem-test123@mail.ru"; //твоя почта, с которой отправляется сообщение
            string smtpPassword = "";//пароль приложения (от почты)

            // Создаем объект клиента SMTP
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                // Настройки аутентификации
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(""); // Укажите адрес получателя
                    mailMessage.Subject = "Заголовок сообщения (тема)";
                    mailMessage.Body = $"Текст сообщения";

                    try
                    {
                        // Отправляем сообщение
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Сообщение успешно отправлено.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
                    }
                }
            }
        }
