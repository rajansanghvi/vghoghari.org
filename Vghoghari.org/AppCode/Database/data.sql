update    app_cities c
left join app_states s
on        c.state_id = s.id
left join app_countries co
on        s.country_id = co.id
set       c.country_id = co.id;