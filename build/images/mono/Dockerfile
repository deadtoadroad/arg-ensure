FROM mono

RUN nuget update -self && \
    nuget locals temp -clear

COPY ./user.sh /root/
RUN chmod +x /root/user.sh && /root/user.sh
